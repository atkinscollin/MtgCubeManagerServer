namespace MtgCubeManagerServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUriAndRelatedUriColumnsToCard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "ImageUriPng", c => c.String());
            AddColumn("dbo.Cards", "ImageUriBorderCrop", c => c.String());
            AddColumn("dbo.Cards", "ImageUriArtCrop", c => c.String());
            AddColumn("dbo.Cards", "ImageUriLarge", c => c.String());
            AddColumn("dbo.Cards", "ImageUriNormal", c => c.String());
            AddColumn("dbo.Cards", "ImageUriSmall", c => c.String());
            AddColumn("dbo.Cards", "RelatedUriTcgplayerDecks", c => c.String());
            AddColumn("dbo.Cards", "RelatedUriEdhrec", c => c.String());
            AddColumn("dbo.Cards", "RelatedUriMtgtop8", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "RelatedUriMtgtop8");
            DropColumn("dbo.Cards", "RelatedUriEdhrec");
            DropColumn("dbo.Cards", "RelatedUriTcgplayerDecks");
            DropColumn("dbo.Cards", "ImageUriSmall");
            DropColumn("dbo.Cards", "ImageUriNormal");
            DropColumn("dbo.Cards", "ImageUriLarge");
            DropColumn("dbo.Cards", "ImageUriArtCrop");
            DropColumn("dbo.Cards", "ImageUriBorderCrop");
            DropColumn("dbo.Cards", "ImageUriPng");
        }
    }
}
