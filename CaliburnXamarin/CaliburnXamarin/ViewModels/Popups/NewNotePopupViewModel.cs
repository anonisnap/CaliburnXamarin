using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

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

		public void AddNote( )
		{

		}

		public void Cancel( )
		{

		}
	}
}