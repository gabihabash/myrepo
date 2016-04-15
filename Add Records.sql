delete from Shipments;
delete from PackageReceivers;

declare @cnt int = 1;
declare @total int = 10;
begin
	while @cnt <= @total
	begin
		insert into PackageReceivers (ReceiverNbr, FirstName, LastName) values(@cnt, 'PR', 'H');
		insert into Shipments (TrackingNbr, AffiliateReferenceNbr, PackageReceiverNbr, ShipmentTypeId)
			values (@cnt, 0, @cnt, 1);
		set @cnt = @cnt + 1;
	end
end