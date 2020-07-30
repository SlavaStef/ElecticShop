namespace ElectricShop.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Changeproductmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "BrandId", newName: "Brand_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.Products", name: "SubCategoryId", newName: "SubCategory_Id");
            RenameIndex(table: "dbo.Products", name: "IX_BrandId", newName: "IX_Brand_Id");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameIndex(table: "dbo.Products", name: "IX_SubCategoryId", newName: "IX_SubCategory_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_SubCategory_Id", newName: "IX_SubCategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_Brand_Id", newName: "IX_BrandId");
            RenameColumn(table: "dbo.Products", name: "SubCategory_Id", newName: "SubCategoryId");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Products", name: "Brand_Id", newName: "BrandId");
        }
    }
}
