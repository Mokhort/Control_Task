Select * from Info 
inner join Type_animal 
on Type_animal.Id=Info.type where Type_animal.type_name='Ship' and
DATEDIFF(dd, Info.date_of_birth, GETDATE()) < 365

