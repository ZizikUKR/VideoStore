namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertValuesToMemberShip : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,Name, DurationInMonth, DiscountRate) VALUES(2,30,'Monthly',1,10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,Name, DurationInMonth, DiscountRate) VALUES(3,90,'Quater of the year',3,15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,Name, DurationInMonth, DiscountRate) VALUES(4,300,'Without limits',12,20)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee,Name, DurationInMonth, DiscountRate) VALUES(1,0,'Free',0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
