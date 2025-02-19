import numpy as np
import matplotlib.pyplot as plt

# Definimos a y b para la ecuación ax + by = 0
a = 1
b = 2

# Generamos valores de x
x_values = np.linspace(-10, 10, 400)

# Calculamos los valores correspondientes de y usando la ecuación ax + by = 0 => y = -a/b * x
y_values = -a/b * x_values

# Graficamos la recta
plt.figure(figsize=(6,6))
plt.plot(x_values, y_values, label=f'{a}x + {b}y = 0', color='b')
plt.axhline(0, color='black',linewidth=1)  # Eje X
plt.axvline(0, color='black',linewidth=1)  # Eje Y

# Etiquetas y título
plt.xlabel('x')
plt.ylabel('y')
plt.title('Gráfica de la recta ax + by = 0')

# Límites y leyenda
plt.xlim(-10, 10)
plt.ylim(-10, 10)
plt.grid(True)
plt.legend()

# Mostrar la gráfica
plt.show()
