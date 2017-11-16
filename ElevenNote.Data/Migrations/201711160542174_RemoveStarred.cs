namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStarred : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notes", "IsStarred");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "IsStarred", c => c.Boolean(nullable: false));
        }
    }
}
