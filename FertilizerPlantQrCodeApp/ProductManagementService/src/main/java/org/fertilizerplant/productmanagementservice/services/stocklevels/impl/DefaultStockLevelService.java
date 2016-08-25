package org.fertilizerplant.productmanagementservice.services.stocklevels.impl;

import java.util.List;

import org.fertilizerplant.productmanagementservice.models.stocklevels.StockLevel;
import org.fertilizerplant.productmanagementservice.repositories.stocklevels.StockLevelRepository;
import org.fertilizerplant.productmanagementservice.services.stocklevels.StockLevelService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

@Service
@Qualifier("stockLevelService")
public class DefaultStockLevelService implements StockLevelService{

	@Autowired
	private StockLevelRepository stockLevelRepository;

	public List<StockLevel> getAllStockLevels()
	{
		return stockLevelRepository.findAll();
	}
	public StockLevel save(StockLevel stockLevel)
	{
		return stockLevelRepository.save(stockLevel);
	}
}
