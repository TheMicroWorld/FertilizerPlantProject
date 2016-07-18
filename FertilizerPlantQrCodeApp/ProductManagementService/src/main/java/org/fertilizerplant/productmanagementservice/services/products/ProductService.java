package org.fertilizerplant.productmanagementservice.services.products;

import java.util.List;

import org.fertilizerplant.productmanagementservice.models.products.Product;

public interface ProductService {
	
	List<Product> getAllProducts();
	Product save(Product product);
}
