using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
            new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 75 },
            new Book { Id = 2, Title = "Mesnevi", Price = 175 },
            new Book { Id = 4, Title = "Sefiller", Price = 200 },
            new Book { Id = 5, Title = "Suç ve Ceza", Price = 150 },
            new Book { Id = 3, Title = "Devlet", Price = 375 },
            new Book { Id = 6, Title = "Savaş ve Barış", Price = 300 },
            new Book { Id = 7, Title = "Karamazov Kardeşler", Price = 250 },
            new Book { Id = 8, Title = "İlahi Komedya", Price = 450 },
            new Book { Id = 9, Title = "1984", Price = 125 },
            new Book { Id = 10, Title = "Hayvan Çiftliği", Price = 100 },
            new Book { Id = 11, Title = "Don Kişot", Price = 275 },
            new Book { Id = 12, Title = "Beyaz Zambaklar Ülkesi", Price = 175 },
            new Book { Id = 13, Title = "Simyacı", Price = 225 },
            new Book { Id = 14, Title = "Anna Karenina", Price = 375 },
            new Book { Id = 15, Title = "Ulysses", Price = 500 },
            new Book { Id = 16, Title = "Yeraltından Notlar", Price = 95 },
            new Book { Id = 17, Title = "Madame Bovary", Price = 180 },
            new Book { Id = 18, Title = "Kürk Mantolu Madonna", Price = 140 },
            new Book { Id = 19, Title = "Çalıkuşu", Price = 125 },
            new Book { Id = 20, Title = "Moby Dick", Price = 350 },
            new Book { Id = 21, Title = "Kırmızı ve Siyah", Price = 160 },
            new Book { Id = 22, Title = "Monte Cristo Kontu", Price = 300 },
            new Book { Id = 23, Title = "Bülbülü Öldürmek", Price = 180 },
            new Book { Id = 24, Title = "Germinal", Price = 200 },
            new Book { Id = 25, Title = "Küçük Prens", Price = 80 },
            new Book { Id = 26, Title = "Yüzyıllık Yalnızlık", Price = 275 },
            new Book { Id = 27, Title = "Şeker Portakalı", Price = 90 },
            new Book { Id = 28, Title = "Fahrenheit 451", Price = 125 },
            new Book { Id = 29, Title = "Lolita", Price = 230 },
            new Book { Id = 30, Title = "Babasız Evler", Price = 150 }
            );
        }
    }
}
