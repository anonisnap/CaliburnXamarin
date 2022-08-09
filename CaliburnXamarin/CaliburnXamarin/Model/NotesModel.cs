using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CaliburnXamarin.Model
{
	public class NotesModel
	{
		public ObservableCollection<Note> Notes { get; }

		public NotesModel( )
		{
			Notes = new ObservableCollection<Note>( );
		}
		public void AddNewNote(Note n)
		{
			Notes.Add(n);
		}

	}
}
