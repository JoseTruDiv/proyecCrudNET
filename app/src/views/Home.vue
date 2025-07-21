<script setup lang="ts">

</script>

<template>
    <div class="d-flex justify-center g-2 pt-3">
        <div class="row-column align-center justify-center p-2" style="border: 2px solid #000;border-radius: 1rem;">
            <h3>Añadir Usuario</h3>
             <form class="w-100 pt-1 row-column g-1" action="http://localhost:5090/addUsuario/" method="get">
                <input class="w-100 p-1 text" type="text" name="nombre" id="nombre" placeholder="Dime el nombre del usuario">
                <input class="w-100 p-1 text" type="text" name="direccion" id="direccion" placeholder="Dime la dirección del usuario">
                <input class="w-100 p-1 text" type="text" name="telefono" id="telefono" placeholder="Dime el teléfono del usuario">
                <input class="w-100 p-1 text" type="text" name="email" id="email" placeholder="Dime el email del usuario">
                <button type="submit" class="btn text">Enviar</button>
            </form>
        </div>
         <div class="row-column align-center justify-center p-2" style="border: 2px solid #000;border-radius: 1rem;">
            <h3>Borrar Usuario</h3>
            <form class="w-100 pt-1 row-column g-1" action="http://localhost:5090/delUsuario/" method="get">
                <input class="w-100 p-1 text" type="text" name="id" id="id" placeholder="Dime el id del usuario">
                <button type="submit" class="btn text">Enviar</button>
            </form>
        </div>
    </div>
</template>

