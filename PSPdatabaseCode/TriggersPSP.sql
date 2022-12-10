drop trigger if exists trgStoreOldItems;

delimiter //
create trigger tgrStoreOldItems before delete on items for each row
begin
	insert into historicalitems (itemId, item_name, description, Price, Quantity, Pettype, removedOn) values (old.itemId, old.item_name, old.description, old.Price, old.Quantity, old.Pettype, curdate());
end;
// delimiter ;