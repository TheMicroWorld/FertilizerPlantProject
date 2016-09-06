package org.fertilizerplant.productmanagementservice.services.products.impl;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import org.fertilizerplant.common.synchronization.download.BaseSyncDataRecv;
import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.productmanagementservice.models.products.QProduct;
import org.fertilizerplant.productmanagementservice.repositories.products.ProductRepository;
import org.fertilizerplant.productmanagementservice.services.products.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.mysema.query.types.Predicate;

@Service
@Qualifier("productService")
public class DefaultProductService implements ProductService
{
	@Autowired
	private ProductRepository productRepository;
	
	public List<Product> getAllProducts()
	{
		return productRepository.findAll();
	}
	
	public List<Product> getAllUnSynchedProducts()
	{
		QProduct product = QProduct.product;
		Predicate productUnsynched = product.syncStatus.eq(false);
		return (List<Product>) productRepository.findAll(productUnsynched);
	}
	public Product save(Product product)
	{
		return productRepository.save(product);
	}
	
	public List<String> getAllProductNames()
	{
		List<Product> products = getAllProducts();
		List<String> productNames = products.stream().map(p->p.getProductName()).collect(Collectors.toList());
		return productNames;
	}

	@Override
	public Product findProductById(String productId) {
		
		return productRepository.findOne(productId);
	}

	@Transactional
	public void updateProductsSyncStatus(List<BaseSyncDataRecv> dataReceived)
	{
		List<Product> products = new ArrayList<Product>();
		for(BaseSyncDataRecv data : dataReceived)
		{
			Product product = productRepository.findOne(data.getId());
			product.setSyncStatus(data.isSyncStatus());
			products.add(product);
		}
		productRepository.bulkSave(products);
	}
}


