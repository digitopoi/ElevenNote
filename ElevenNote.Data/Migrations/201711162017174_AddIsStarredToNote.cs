namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsStarredToNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "IsStarred");
        }
    }
}
