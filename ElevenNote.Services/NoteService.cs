using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<NoteListItemViewModel> GetNotes()
        {
            using (var context = new ElevenNoteDbContext())
            {
                return context
                        .Notes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NoteListItemViewModel
                                {
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    Content = e.Content,
                                    //IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc,
                                }
                        ).ToArray();
            }
        }

        public NoteDetailViewModel GetNoteById(int noteId)
        {
            NoteEntity entity;

            using (var context = new ElevenNoteDbContext())
            {
                entity = context
                        .Notes
                        .SingleOrDefault(e => e.OwnerId == _userId && e.NoteId == noteId);
            }

            //  TODO: Handle note not found
            if (entity == null) return new NoteDetailViewModel();

            return
                new NoteDetailViewModel
                {
                    NoteId = entity.NoteId,
                    Title = entity.Title,
                    Content = entity.Content,
                    //IsStarred = entity.IsStarred,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
        }

        public bool CreateNote(NoteCreateViewModel vm)
        {
            using (var context = new ElevenNoteDbContext())
            {
                var entity =
                    new NoteEntity
                    {
                        OwnerId = _userId,
                        Title = vm.Title,
                        Content = vm.Content,
                        CreatedUtc = DateTime.UtcNow

                    };

                context.Notes.Add(entity);

                //  return true if exactly one item added to the database
                //  else, returns false
                return context.SaveChanges() == 1;
            }
        }

        public bool UpdateNote(NoteEditViewModel model)
        {
            NoteEntity entity;

            using (var context = new ElevenNoteDbContext())
            {
                entity = context
                    .Notes
                    .SingleOrDefault(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return context.SaveChanges() == 1;
            }

             
        }
        //public bool DeleteNote(int noteId)
        //{
        //    using (var context = new ElevenNoteDbContext())
        //    {
        //        var entity = context
        //                        .Notes
        //                        .Single(e => e.OwnerId == _userId && e.NoteId == noteId);

        //        //  TODO: Handle not found

        //        context.Notes.Remove(entity);

        //        return context.SaveChanges() == 1;
        //    }

        //}
    }
}
