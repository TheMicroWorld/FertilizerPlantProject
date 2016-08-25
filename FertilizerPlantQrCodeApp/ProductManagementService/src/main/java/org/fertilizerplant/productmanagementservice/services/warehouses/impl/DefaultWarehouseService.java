package org.fertilizerplant.productmanagementservice.services.warehouses.impl;

import java.util.List;

import org.fertilizerplant.productmanagementservice.models.warehouses.Warehouse;
import org.fertilizerplant.productmanagementservice.repositories.warehouses.WarehouseRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

@Service
@Qualifier("warehouseService")
public class DefaultWarehouseService {
	
	@Autowired
	private WarehouseRepository warehouseRepository;
	
	public List<Warehouse> getAllWarehouses()
	{
		return warehouseRepository.findAll();
	}
	public Warehouse save(Warehouse warehouse)
	{
		return warehouseRepository.save(warehouse);
	}
}
