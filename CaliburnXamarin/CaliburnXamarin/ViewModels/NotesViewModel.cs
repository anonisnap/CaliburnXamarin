using Caliburn.Micro;
using CaliburnXamarin.Model;
using CaliburnXamarin.Services;
using CaliburnXamarin.ViewModels.Popups;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CaliburnXamarin.ViewModels
{
	public class NotesViewModel : Screen
	{
		#region Fields
		private readonly NavigationService _popNav;
		#endregion
		#region Properties
		public string PageInformation { get; set; }

		public string NoteCount => $"Notes: {Notes.Count}";

		public string AddNewNoteButton { get; set; }

		public string RemoveNoteButton { get; set; }
		public ObservableCollection<Note> Notes { get; }


		public Note SelectedNote { get; set; }
		#endregion

		public NotesViewModel(NavigationService navigationService, NotesModel model)
		{
			PageInformation = "Temporary Notes";
			AddNewNoteButton = "Add New";
			RemoveNoteButton = "Remove";

			_popNav = navigationService;

			Notes = model.Notes;
			Notes.CollectionChanged += UpdateNoteCount;
		}


		public async void CreateNewNote( )
		{
			//await _popNav.PushAsync();
			NewNotePopupViewModel vm = IoC.Get<NewNotePopupViewModel>( );
			await _popNav.NavigateToPopupViewModelAsync(vm);

			// Notify of changes
			NotifyOfPropertyChange(( ) => NoteCount);
		}

		public async void RemoveSelectedNote( )
		{
			// Get the Selected Note
			if ( SelectedNote == null )
			{
				return;
			}

			// Ask User if they are sure
			bool shouldRemove = await Application.Current.MainPage.DisplayAlert("Remove?", SelectedNote.Title, "Ok", "Cancel");

			if ( !shouldRemove )
			{
				return;
			}

			// Remove the Note
			Notes.Remove(SelectedNote);
			SelectedNote = null;
		}

		public void UpdateNoteCount(object sender, NotifyCollectionChangedEventArgs e)
		{
			NotifyOfPropertyChange(( ) => NoteCount);
		}
	}
}
