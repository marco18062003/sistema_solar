import numpy as np
import matplotlib.pyplot as plt
a_merc = 0.39  
e_merc = 0.4 
a_tierra = 1.0  
e_tierra = 0.3 
theta = np.linspace(0, 2 * np.pi, 100)
r_merc = a_merc * (1 - e_merc**2) / (1 + e_merc * np.cos(theta))  
r_tierra = a_tierra * (1 - e_tierra**2) / (1 + e_tierra * np.cos(theta))  
x_merc = r_merc * np.cos(theta)
y_merc = r_merc * np.sin(theta)

x_tierra = r_tierra * np.cos(theta)
y_tierra = r_tierra * np.sin(theta)


plt.figure(figsize=(8, 8))
plt.plot(x_merc, y_merc, label="Órbita Mercurio", color="black")
plt.plot(x_tierra, y_tierra, label="Órbita Tierra", color="pink")

# Dibujar el Sol en el centro
plt.scatter(0, 0, color="black", s=200, label="Sol", marker='.')

# Configuración del gráfico
plt.gca().set_aspect('equal', adjustable='box')
plt.title("Órbitas Elípticas de Mercurio y la Tierra (más elípticas)")
plt.xlabel("Distancia en AU")
plt.ylabel("Distancia en AU")
plt.legend()
plt.grid(True)

# Mostrar el gráfico
plt.show()
