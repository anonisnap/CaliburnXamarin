using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using CaliburnXamarin.Model;

namespace CaliburnXamarin.ViewModels.Popups
{
	public class NewNotePopupViewModel : Screen
	{
		public string NoteTitleInfo { get; set; }
		public string NoteDescInfo { get; set; }
		public string BtnAdd { get; set; }
		public string BtnCancel { get; set; }

		// User Inputs
		public string NoteTitleInput { get; set; }
		public string NoteDescInput { get; set; }

		public NewNotePopupViewModel( )
		{
			NoteTitleInfo = "Title";
			NoteDescInfo = "Description";
			BtnAdd = "Add";
			BtnCancel = "Cancel";
		}

		public async void AddNote( )
		{
			Note n = new Note( )
			{
				Title = NoteTitleInput,
				Description = NoteDescInput
			};

			var model = IoC.Get<NotesModel>( );
			model.AddNewNote(n);

			// TODO: Close the Popup
			//await TryCloseAsync( );
		}

		public async void Cancel( )
		{
			// TODO: Close the Popup
			//await TryCloseAsync( );
		}
	}
}