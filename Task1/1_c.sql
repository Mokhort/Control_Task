Select * From Info
inner join Type_animal 
on Type_animal.Id=Info.type where Type_animal.type_name='Cow' and Info.Id=(

SELECT parent_1
FROM Info
where DATEDIFF(yy, Info.date_of_birth, GETDATE()) <= 5
GROUP BY parent_1
HAVING COUNT(*) >= 2)
