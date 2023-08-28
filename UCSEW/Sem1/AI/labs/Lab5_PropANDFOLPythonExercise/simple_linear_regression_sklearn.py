import numpy as np
from sklearn.linear_model import LinearRegression

Height = np.array([171,165,145,162,156])
Weight = np.array([80,60,80,62,65])

clf = LinearRegression()
clf.fit(Height.reshape(-1,1),Weight)

a=clf.predict([[89]])
print(a)


