using System;

namespace ElevenNote.Models
{
    public class NoteDetailViewModel
    {
        public int NoteId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        //  public bool IsStarred { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        //  public override string ToString() => $"[{NoteId}] {Title}";

    }
}
