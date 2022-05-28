# List comprehensions

# nums = [0,1,2,3,4,5,6,7,8,9]
# comp = [n for n in nums]
# print(comp)



# Generators

nums = (n for n in range(0, 1000))
squares_of_even_nums = (n*n for n in nums if n%2 == 0)
# squares_of_even_nums = [n*n for n in nums if n%2 == 0]
print(squares_of_even_nums)