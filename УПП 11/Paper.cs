using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using УПП_11;


namespace УПП_11
{
    public class Paper
    {
        public string title { get; set; }
        public Person author { get; set; }
        public DateTime publicationDate { get; set; }

        public Paper(string title, Person author, DateTime publicationDate)
        {
            this.title = title;
            this.author = author;
            this.publicationDate = publicationDate;
        }

        public Paper()
        {
            title = "по умолчанию";
            author = new Person();
            publicationDate = new DateTime();
        }

        public override string ToString()
        {
            return $"Название: {title}, Автор: {author.ToString()}, Дата публикации: {publicationDate.ToShortDateString()}";
        }

        // Виртуальный метод DeepCopy() для создания полной копии объекта
        public virtual Paper DeepCopy()
        {
            // Создаем новую копию автора
            Person newAuthor = author.DeepCopy();

            // Создаем новую копию Paper
            return new Paper(title, newAuthor, publicationDate);
        }
    }
}
