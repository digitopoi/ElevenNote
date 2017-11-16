namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoteEntity1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "Content", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "Content", c => c.String(nullable: false));
        }
    }
}
