namespace Adesso.Data.Migrations.MigrationSteps;

[Migration(2)]
public class Locations : Migration {
    public override void Up()
    {
        Create.Table(TableNames.Locations)
            .WithColumn(ColumnNames.Id).AsInt32().PrimaryKey().NotNullable()
            .WithColumn("LocationName").AsString(EntityConfigs.NameLength).NotNullable();
        
        Insert.IntoTable(TableNames.Locations)
            .Row(new { Id = 34, LocationName = "İstanbul" })
            .Row(new { Id = 59, LocationName = "Tekirdağ" });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}