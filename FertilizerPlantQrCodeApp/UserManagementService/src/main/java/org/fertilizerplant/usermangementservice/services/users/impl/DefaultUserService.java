package org.fertilizerplant.usermangementservice.services.users.impl;

import java.util.List;
import java.util.stream.Collectors;

import org.fertilizerplant.usermangementservice.models.users.User;
import org.fertilizerplant.usermangementservice.repositories.users.UserRepository;
import org.fertilizerplant.usermangementservice.services.users.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

@Service
@Qualifier("userService")
public class DefaultUserService implements UserService
{
	@Autowired(required=false)
	private UserRepository userRepository;
	
	public List<User> getAllUsers()
	{
		return userRepository.findAll();
	}
	
	public User save(User user)
	{
		return userRepository.save(user);
	}
	
	public List<String> getAllUserNames()
	{
		List<User> users = getAllUsers();
		List<String> userNames = users.stream().map(u->u.getName()).collect(Collectors.toList());
		return userNames;
	}
}
