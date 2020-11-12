namespace PDS2_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cantidadproducto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Cantidad");
        }
    }
}
