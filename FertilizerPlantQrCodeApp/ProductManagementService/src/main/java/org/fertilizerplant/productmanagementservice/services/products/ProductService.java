package org.fertilizerplant.productmanagementservice.services.products;

import java.util.List;

import org.fertilizerplant.common.synchronization.download.BaseSyncDataRecv;
import org.fertilizerplant.productmanagementservice.models.products.Product;

public interface ProductService {
	
	List<Product> getAllProducts();
	Product save(Product product);
	List<String> getAllProductNames();
	Product findProductById(String productId);
	void updateProductsSyncStatus(List<BaseSyncDataRecv> dataReceived);
	List<Product> getAllUnSynchedProducts();
}
