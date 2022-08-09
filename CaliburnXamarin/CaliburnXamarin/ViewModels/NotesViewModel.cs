﻿using Caliburn.Micro;
using CaliburnXamarin.Model;
using System.Collections.Generic;

namespace CaliburnXamarin.ViewModels
{
	public class NotesViewModel : Screen
	{
		#region Properties
		public string PageInformation
		{
			get;
			set;
		}
		public string NoteCount => $"Notes: {Notes.Count}";
		public string AddNewNoteButton
		{
			get;
			set;
		}
		public List<Note> Notes
		{
			get;
		}
		#endregion

		public NotesViewModel( )
		{
			Notes = new List<Note>( );
			PageInformation = "Notes";
			AddNewNoteButton = "Add New";
		}

		public void CreateNewNote( )
		{
			Note n = new Note( )
			{
				Message = "New Note"
			};

			Notes.Add(n);

			NotifyOfPropertyChange(( ) => Notes);
			NotifyOfPropertyChange(( ) => NoteCount);
		}
	}
}
