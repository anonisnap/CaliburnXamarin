using Caliburn.Micro;
using CaliburnXamarin.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CaliburnXamarin.ViewModels
{
	public class NotesViewModel : Screen
	{
		#region Properties
		public string PageInformation { get; set; }

		public string NoteCount => $"Notes: {Notes.Count}";

		public string AddNewNoteButton { get; set; }

		public string RemoveNoteButton { get; set; }

		public ObservableCollection<Note> Notes { get; }

		public Note SelectedNote { get; set; }
		#endregion

		public NotesViewModel( )
		{
			Notes = new ObservableCollection<Note>( );
			PageInformation = "Notes";
			AddNewNoteButton = "Add New";
			RemoveNoteButton = "Remove";
		}

		public async void CreateNewNote( )
		{
			// Get Message from the User via Prompt
			string msg = await Application.Current.MainPage.DisplayPromptAsync("New Note", "Write your new note");

			Note n = new Note( )
			{
				Message = msg
			};


			// Add Note to the Collection
			Notes.Add(n);

			// Notify of changes
			NotifyOfPropertyChange(( ) => Notes);
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
			bool shouldRemove = await Application.Current.MainPage.DisplayAlert("Remove?", SelectedNote.Message, "Ok", "Cancel");

			if ( !shouldRemove )
			{
				return;
			}

			// Remove the Note
			Notes.Remove(SelectedNote);

			// Notify of changes
			NotifyOfPropertyChange(( ) => Notes);
			NotifyOfPropertyChange(( ) => NoteCount);
		}
	}
}
