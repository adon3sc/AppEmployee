
--use dbEmployee

--create table Employee (
--	Emp_ID int primary key identity(1, 1),
--	Emp_LastName varchar(250),
--	Emp_FirstName varchar (250),
--	Emp_Phone nvarchar(20),
--	Emp_Zip nvarchar(20),
--	Emp_HireDate datetime
--)

alter procedure sp_employee_records
	@option int ,
	@emp_id int = 0,
	@emp_LastName varchar(250) = '',
	@emp_FirstName varchar(250) = '',
	@emp_Phone nvarchar(20) = '',
	@emp_Zip nvarchar(20) = '',
	@emp_HireDate nvarchar(20) = ''
AS
BEGIN
	SET NOCOUNT ON;
	set dateformat mdy
	if @option = 1
	begin
		select Emp_ID, Emp_FirstName, Emp_LastName, Emp_Phone, Emp_Zip, Emp_HireDate 
		from Employee
	end
	if @option = 2
	begin
		insert into Employee (Emp_FirstName, Emp_LastName, Emp_Phone, Emp_Zip, Emp_HireDate)
		values(@emp_FirstName, @emp_LastName, @emp_Phone, @emp_Zip, convert(datetime, @emp_HireDate, 23))
	end
	if @option = 3
	begin
		update Employee set Emp_FirstName = @emp_FirstName, Emp_LastName = @Emp_LastName,
		Emp_Phone = @emp_Phone, Emp_Zip = @emp_Zip, Emp_HireDate = @emp_HireDate
		where Emp_ID = @emp_id
	end
	if @option = 4
	begin
		delete Employee where Emp_ID = @emp_id
	end
END
GO


