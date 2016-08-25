package org.fertilizerplant.productmanagementservice.services.stocklevels;

import java.util.List;

import org.fertilizerplant.productmanagementservice.models.stocklevels.StockLevel;

public interface StockLevelService {
	List<StockLevel> getAllStockLevels();
	StockLevel save(StockLevel stockLevel);
}
