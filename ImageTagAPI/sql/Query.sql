SELECT * FROM "Pictures";

SELECT * FROM "Tags";

INSERT INTO "Tags" (PictureId, Name)
	SELECT 1, "charzzz"
	UNION 
	SELECT 2, "char"
	UNION 
	SELECT 3, "char"
;


SELECT
   table_name, 
   column_name, 
   data_type,
   is_nullable,
	table_catalog 
FROM 
   information_schema.columns
WHERE 
   lower(TABLE_NAME) = 'pictures';