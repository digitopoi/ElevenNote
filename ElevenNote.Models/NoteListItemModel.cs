using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevenNote.Models
{
    public class NoteListItemViewModel
    {
        public int NoteId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "Starred")]
        [UIHint("Starred")]
        public bool IsStarred { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString() => $"[{NoteId}] {Title}";
    }
}