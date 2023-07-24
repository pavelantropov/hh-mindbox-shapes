SELECT p.name, c.name FROM products p
LEFT JOIN products_categories pc
	ON p.id = pc.product_id
LEFT JOIN categories c
	ON c.id = pc.category_id
