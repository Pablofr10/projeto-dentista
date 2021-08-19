<template>
  <div>
    <nav class="bg-gray-100">
      <div class="max-w-6xl mx-auto px-8">
        <div class="flex justify-between">
          <div class="flex space-x-4">
            <!-- logo -->
            <div>
              <a
                href="#"
                class="flex items-center py-5 px-2 text-gray-700 hover:text-gray-900"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  class="h-6 w-6 mr-1 text-blue-400"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M12 19l9 2-9-18-9 18 9-2zm0 0v-8"
                  />
                </svg>
                <span class="font-bold">Clinica VueNet</span>
              </a>
            </div>
            <!-- primary nav -->
            <div class="hidden md:flex items-center space-x-1">
              <router-link
                href="#"
                class="py-5 px-3 text-gray-700 hover:text-gray-900"
                v-for="menu in menus"
                :to="menu.rota"
                :key="menu.id"
              >
                {{ menu.nome }}
              </router-link>
            </div>
          </div>
          <!-- secoundary nav-->
          <div class="hidden md:flex items-center space-x-1">
            <a href="" class="py-5 px-3">Login</a>
            <a
              href=""
              class="py-3 px-3 bg-yellow-400 hover:bg-yellow-300 text-yellow-900 hover:text-yellow-800
                            rounded transition duration-300"
              >SignUp</a
            >
          </div>

          <!-- mobile menu -->
          <div class="md:hidden flex items-center">
            <button @click="mostraMenuMobile = !mostraMenuMobile">
              <svg
                class="h-5 w-5"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M3 5a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 10a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 15a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1z"
                  clip-rule="evenodd"
                />
              </svg>
            </button>
          </div>
        </div>
      </div>

      <div class="mobile-menu md:hidden" v-show="mostraMenuMobile">
        <a href="#" class="block py-2 px-4 text-sm hover:bg-gray-200"
          >Features</a
        >
        <a href="#" class="block py-2 px-4 text-sm hover:bg-gray-200"
          >Pricing</a
        >
      </div>
    </nav>

    <div class="px-3">
      <slot></slot>
    </div>
  </div>
</template>

<script>
import { ref } from "vue";
export default {
  setup() {
    const mostraMenuMobile = ref(false);
    const menus = [
      { id: 1, nome: "Consultas", rota: "/consultas" },
      { id: 2, nome: "Pacientes", rota: "/paciente" },
      { id: 3, nome: "Profissional", rota: "/profissional" }
    ];
    return {
      mostraMenuMobile,
      menus
    };
  }
};
</script>

<style lang="scss" scoped></style>
