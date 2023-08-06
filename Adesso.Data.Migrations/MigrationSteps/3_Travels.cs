namespace Adesso.Data.Migrations.MigrationSteps;

[Migration(3)]
public class Travels : Migration
{
    private readonly string UserForeignKey = $"FK_{TableNames.Travels}_{TableNames.Users}_Id";
    private readonly string FromLocationForeignKey = $"FK_{TableNames.Travels}_{TableNames.Locations}_FromLocationId";
    private readonly string WhereLocationForeignKey = $"FK_{TableNames.Travels}_{TableNames.Locations}_WhereLocationId";

    public override void Up()
    {
        Create.Table(TableNames.Travels)
            .WithColumn(ColumnNames.Id).AsGuid().PrimaryKey().NotNullable()
            .WithColumn("UserId").AsGuid().NotNullable().ForeignKey(UserForeignKey, TableNames.Users, ColumnNames.Id)
            .WithColumn("FromLocationId").AsInt32().NotNullable()
            .ForeignKey(FromLocationForeignKey, TableNames.Locations, ColumnNames.Id)
            .WithColumn("WhereLocationId").AsInt32().NotNullable()
            .ForeignKey(WhereLocationForeignKey, TableNames.Locations, ColumnNames.Id)
            .WithColumn("TravelDateOnUtc").AsDateTime().NotNullable()
            .WithColumn("Description").AsString(EntityConfigs.DescriptionLength).NotNullable()
            .WithColumn("PassengerCount").AsInt32().NotNullable()
            .WithColumn("IsPublished").AsBoolean().NotNullable()
            .WithColumn(ColumnNames.CreatedOnUtc).AsDateTime().NotNullable()
            .WithColumn(ColumnNames.UpdatedOnUtc).AsDateTime().Nullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}