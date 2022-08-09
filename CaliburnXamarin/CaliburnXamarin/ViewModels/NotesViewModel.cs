﻿using Caliburn.Micro;
using CaliburnXamarin.Model;
using CaliburnXamarin.ViewModels.Popups;
using CaliburnXamarin.Views.Popups;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CaliburnXamarin.ViewModels
{
	public class NotesViewModel : Screen
	{
		#region Fields
		private readonly IPopupNavigation _popNav;
		#endregion
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
			PageInformation = "Temporary Notes";
			AddNewNoteButton = "Add New";
			RemoveNoteButton = "Remove";

			_popNav = PopupNavigation.Instance;
		}

		public async void CreateNewNote( )
		{
			await _popNav.PushAsync(new NewNotePopupView());

			return;
			//Thread.Sleep(1000);

			// Get Message from the User via Prompt
			string msg = await Application.Current.MainPage.DisplayPromptAsync("New Note", "Write your new note", accept: "Add", cancel: "Cancel");

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

		protected override Task OnActivateAsync(CancellationToken cancellationToken)
		{
			// Load the notes

			return base.OnActivateAsync(cancellationToken);
		}
		protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
		{
			// Save the notes

			return base.OnDeactivateAsync(close, cancellationToken);
		}
	}
}
