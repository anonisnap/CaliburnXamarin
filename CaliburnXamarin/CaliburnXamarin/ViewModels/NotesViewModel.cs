using Caliburn.Micro;
using CaliburnXamarin.Model;
using CaliburnXamarin.Services;
using CaliburnXamarin.ViewModels.Popups;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace CaliburnXamarin.ViewModels {
	public class NotesViewModel : Screen {
		#region Fields
		private readonly NavigationService _popupNav;
		#endregion
		#region Properties
		public string PageInformation {
			get; set;
		}

		public string NoteCount => $"Notes: {Notes.Count}";

		public string AddNewNoteButton {
			get; set;
		}

		public string RemoveNoteButton {
			get; set;
		}
		public ObservableCollection<Note> Notes {
			get;
		}


		public Note SelectedNote {
			get; set;
		}
		#endregion

		public NotesViewModel(NavigationService navigationService, NotesModel model) {
			PageInformation = "Temporary Notes";
			AddNewNoteButton = "Add New";
			RemoveNoteButton = "Remove";

			_popupNav = navigationService;

			Notes = model.Notes;
			Notes.CollectionChanged += UpdateNoteCount;
		}


		public async void CreateNewNote( ) {
			// Get the Popup View Model from the IoC Container
			NewNotePopupViewModel vm = IoC.Get<NewNotePopupViewModel>( );

			// Open the Popup View
			await _popupNav.NavigateToPopupViewModelAsync(vm);
		}

		public async void RemoveSelectedNote( ) {
			// Check the Selected Note
			if (SelectedNote == null) {
				return;
			}

			// Ask User if they are sure
			bool shouldRemove = await Application.Current.MainPage.DisplayAlert("Remove?", SelectedNote.Title, "Ok", "Cancel");
			if (!shouldRemove) {
				return;
			}

			// Remove the Note
			Notes.Remove(SelectedNote);
			SelectedNote = null;
		}

		public void UpdateNoteCount(object sender, NotifyCollectionChangedEventArgs e) {
			NotifyOfPropertyChange(( ) => NoteCount);
		}
	}
}
