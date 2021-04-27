using System;

namespace DIO.Series.Entities
{
    public class SerieEntity : BaseEntity
    {
        public Genre Genre { get; private set; }
        public string Title { get; private set; }
        public string Overview { get; private set; }
        public int Year { get; private set; }
        public bool Active { get; set; }

        public SerieEntity(int id, Genre genre, string title, string overview, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Overview = overview;
            this.Year = year;
            this.Active = true;
        }

        public override string ToString()
        {
            string text = "";

            text += $"Gênero: {this.Genre} {Environment.NewLine}";
            text += $"Título: {this.Title} {Environment.NewLine}";
            text += $"Descrição: {this.Overview} {Environment.NewLine}";
            text += $"Ano de Lançamento: {this.Year} {Environment.NewLine}";
            text += $"Ativo: {(this.Active ? "Sim" : "Não")}";

            return text;
        }
    }
}