package org.fertilizerplant.productmanagementservice.services.warehouses;

import java.util.List;

import org.fertilizerplant.productmanagementservice.models.warehouses.Warehouse;

public interface WarehouseService {
	List<Warehouse> getAllWarehouses();
	Warehouse save(Warehouse warehouse);
}
