using System;

namespace LMSWithArrayList.Models
{
    public abstract class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }

        protected LibraryItem(int id, string title, string author, int publishYear)
        {
            Id = id;
            Title = title;
            Author = author;
            PublishYear = publishYear;
            IsAvailable = true;
            IsDeleted = false;
            DeletedDate = null;
            DeletedBy = null;
        }

        public void SoftDelete(string deletedBy)
        {
            IsDeleted = true;
            DeletedDate = DateTime.Now;
            DeletedBy = deletedBy;
        }

        public abstract string DisplayInfo();
    }
}