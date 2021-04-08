SELECT Info.gender,Type_animal.type_name,COUNT(*) as count  FROM Info 
inner join Type_animal 
on Type_animal.Id=Info.type 
group by Info.gender, Type_animal.type_name