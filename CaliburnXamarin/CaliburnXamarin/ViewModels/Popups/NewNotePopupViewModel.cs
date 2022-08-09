using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using CaliburnXamarin.Model;
using Rg.Plugins.Popup.Services;

namespace CaliburnXamarin.ViewModels.Popups {
	public class NewNotePopupViewModel : Screen {
		public string NoteTitleInfo {
			get; set;
		}
		public string NoteDescInfo {
			get; set;
		}
		public string BtnAdd {
			get; set;
		}
		public string BtnCancel {
			get; set;
		}
		public string ErrorNotice {
			get; set;
		}

		// User Inputs
		public string NoteTitleInput {
			get; set;
		}
		public string NoteDescInput {
			get; set;
		}

		public NewNotePopupViewModel( ) {
			NoteTitleInfo = "Title";
			NoteDescInfo = "Description";
			BtnAdd = "Add";
			BtnCancel = "Cancel";
		}

		public async void AddNote( ) {
			if (!string.IsNullOrWhiteSpace(NoteTitleInput)) {
				ErrorNotice = "";

				Note n = new Note( ) {
					Title = NoteTitleInput,
					Description = NoteDescInput
				};

				var model = IoC.Get<NotesModel>( );
				model.AddNewNote(n);

				await PopupNavigation.Instance.PopAsync( );
			} else {
				ErrorNotice = "You must have a Title";
			}

			NotifyOfPropertyChange(( ) => ErrorNotice);
		}

		public async void Cancel( ) {
			await PopupNavigation.Instance.PopAsync( );
		}
	}
}