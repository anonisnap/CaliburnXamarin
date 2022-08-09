using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using CaliburnXamarin.Model;

namespace CaliburnXamarin.ViewModels.Popups
{
	public class NewNotePopupViewModel : Screen
	{
		public string NoteTitle { get; set; }
		public string NoteDesc { get; set; }
		public string BtnAdd { get; set; }
		public string BtnCancel { get; set; }

		public NewNotePopupViewModel( )
		{
			NoteTitle = "Title";
			NoteDesc = "Description";
			BtnAdd = "Add";
			BtnCancel = "Cancel";
		}

		public async void AddNote( )
		{
			Note n = new Note( )
			{
				Message = ""
			};

			IoC.Get<NotesModel>( ).AddNewNote(n);

			await TryCloseAsync( );
		}

		public async void Cancel( )
		{
			await TryCloseAsync( );
		}
	}
}