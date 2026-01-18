namespace Vidly2026.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(Id, Name) values (1, 'Pop')");
            Sql("insert into Genres(Id, Name) values (2, 'Rap')");
            Sql("insert into Genres(Id, Name) values (3, 'Rock')");
            Sql("insert into Genres(Id, Name) values (4, 'Jazz')");
            Sql("insert into Genres(Id, Name) values (5, 'Remix')");
        }
        
        public override void Down()
        {
        }
    }
}
