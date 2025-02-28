using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace WhereIsMyBarber.Infra.Migrations.Versions
{
    [Migration(DatabaseVersions.CREATE_TABLE_USER, "Created user table")]
    public class Version000001 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("HashedPassword").AsString(255).NotNullable()
                .WithColumn("Phone").AsString(255).NotNullable()
                .WithColumn("Type").AsInt32().NotNullable();
        }
    }
}