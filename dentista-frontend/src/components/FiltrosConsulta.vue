<template>
  <div>
    <form class="h-20">
      <div class="grid grid-cols-4 gap-6">
        <div class="flex border-grey-light border">
          <input
            class="w-full rounded ml-1"
            type="text"
            placeholder="Buscar por nome..."
          />
          <button
            class="bg-grey-lightest border-grey border-l shadow hover:bg-grey-lightest"
          >
            <span
              class="w-auto flex justify-end items-center text-grey p-2 hover:text-grey-darkest"
            >
              <fa icon="search"></fa>
            </span>
          </button>
        </div>
        <div>
          <div class="mt-1 relative">
            <button
              type="button"
              class="relative w-full bg-white border border-gray-300 rounded-md shadow-sm pl-3 pr-10 py-2 text-left cursor-default focus:outline-none focus:ring-1 focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
              aria-haspopup="listbox"
              aria-expanded="true"
              aria-labelledby="listbox-label"
              @click="mostraOptionsInput = !mostraOptionsInput"
            >
              <span class="flex items-center">
                <img
                  src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                  alt=""
                  class="flex-shrink-0 h-6 w-6 rounded-full"
                />
                <span class="ml-3 block truncate">
                  Tom Cook
                </span>
              </span>
              <span
                class="ml-3 absolute inset-y-0 right-0 flex items-center pr-2 pointer-events-none"
              >
                <!-- Heroicon name: solid/selector -->
                <svg
                  class="h-5 w-5 text-gray-400"
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 20 20"
                  fill="currentColor"
                  aria-hidden="true"
                >
                  <path
                    fill-rule="evenodd"
                    d="M10 3a1 1 0 01.707.293l3 3a1 1 0 01-1.414 1.414L10 5.414 7.707 7.707a1 1 0 01-1.414-1.414l3-3A1 1 0 0110 3zm-3.707 9.293a1 1 0 011.414 0L10 14.586l2.293-2.293a1 1 0 011.414 1.414l-3 3a1 1 0 01-1.414 0l-3-3a1 1 0 010-1.414z"
                    clip-rule="evenodd"
                  />
                </svg>
              </span>
            </button>

            <ul
              class="absolute z-10 mt-1 w-full bg-white shadow-lg max-h-56 rounded-md py-1 text-base ring-1 ring-black ring-opacity-5 overflow-auto focus:outline-none sm:text-sm"
              tabindex="-1"
              role="listbox"
              aria-labelledby="listbox-label"
              aria-activedescendant="listbox-option-3"
              v-if="mostraOptionsInput"
            >
              <li
                class="text-gray-900 cursor-default select-none relative py-2 pl-3 pr-9"
                id="listbox-option-0"
                role="option"
              >
                <div class="flex items-center">
                  <img
                    src="https://images.unsplash.com/photo-1491528323818-fdd1faba62cc?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                    alt=""
                    class="flex-shrink-0 h-6 w-6 rounded-full"
                  />
                  <!-- Selected: "font-semibold", Not Selected: "font-normal" -->
                  <span class="font-normal ml-3 block truncate">
                    Wade Cooper
                  </span>
                </div>

                <span
                  class="text-indigo-600 absolute inset-y-0 right-0 flex items-center pr-4"
                >
                  <svg
                    class="h-5 w-5"
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 20 20"
                    fill="currentColor"
                    aria-hidden="true"
                  >
                    <path
                      fill-rule="evenodd"
                      d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z"
                      clip-rule="evenodd"
                    />
                  </svg>
                </span>
              </li>
            </ul>
          </div>
        </div>
        <div class="pt-1">
          <v-date-picker v-model="range" is-range>
            <template v-slot="{ inputValue, inputEvents }">
              <div class="flex justify-center items-center">
                <input
                  :value="inputValue.start"
                  v-on="inputEvents.start"
                  class="border px-2 py-2 w-full rounded ml-1 focus:outline-none focus:border-indigo-300"
                />
                <svg
                  class="w-4 h-4 mx-2"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M14 5l7 7m0 0l-7 7m7-7H3"
                  />
                </svg>
                <input
                  :value="inputValue.end"
                  v-on="inputEvents.end"
                  class="border px-2 py-2 w-full rounded ml-1 focus:outline-none focus:border-indigo-300"
                />
              </div>
            </template>
          </v-date-picker>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { ref, watch } from "vue";
export default {
  setup() {
    const mostraOptionsInput = ref(false);
    const range = ref({
      start: new Date(),
      end: new Date()
    });

    watch(range, novo => {
      console.log(novo);
    });

    return {
      mostraOptionsInput,
      range
    };
  }
};
</script>

<style scoped></style>
