namespace Adesso.Data.Migrations.MigrationSteps;

[Migration(1)]
public class Users : Migration
{
    public override void Up()
    {
        Create.Table(TableNames.Users)
            .WithColumn(ColumnNames.Id).AsGuid().PrimaryKey().NotNullable()
            .WithColumn(ColumnNames.CreatedOnUtc).AsDateTime().NotNullable()
            .WithColumn(ColumnNames.UpdatedOnUtc).AsDateTime().Nullable();

        Insert.IntoTable(TableNames.Users)
            .Row(new { Id = new Guid("45773bfd-e1d1-4739-8b08-bb94f7a394cb"), CreatedOnUtc = DateTime.UtcNow })
            .Row(new { Id = new Guid("2b3bc3f4-40dd-4057-9831-076a90b0e7fe"), CreatedOnUtc = DateTime.UtcNow });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}