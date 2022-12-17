drop function if exists TotalCosts; 
 DELIMITER //
	create function TotalCosts( Ordid int) 
		returns double 
		DETERMINISTIC
		begin
        declare stateTax double;
        declare stateID int;
        declare total double;
       
		set stateID = (select state_ID from (customer inner join orders on customer.cust_id =orders.Cust_Id) where orderID = OrdID);
        set stateTax = 1 +(select tax from states where state_id= stateID);
	
		set total = (select sum(price) from ordercontent where orderID=OrdID) * stateTax; 
		return (total);
		end;
// Delimiter ;

