namespace Adesso.Data.Migrations.MigrationSteps;

[Migration(4)]
public class Reservations : Migration {
    private readonly string UserForeignKey = $"FK_{TableNames.Reservations}_{TableNames.Users}_Id";
    private readonly string TravelForeignKey = $"FK_{TableNames.Reservations}_{TableNames.Travels}_Id";
    
    public override void Up()
    {
        Create.Table(TableNames.Reservations)
            .WithColumn(ColumnNames.Id).AsGuid().PrimaryKey().NotNullable()
            .WithColumn("UserId").AsGuid().NotNullable().ForeignKey(UserForeignKey, TableNames.Users, ColumnNames.Id)
            .WithColumn("TravelId").AsGuid().NotNullable()
            .ForeignKey(TravelForeignKey, TableNames.Travels, ColumnNames.Id)
            .WithColumn("PassengerNumber").AsInt32().NotNullable()
            .WithColumn("IsApproved").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}