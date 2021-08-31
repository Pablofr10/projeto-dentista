<template>
  <div class="flex flex-col">
    <div class="-my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
      <div class="py-2 align-middle inline-block min-w-full sm:px-6 lg:px-8">
        <div
          class="shadow overflow-hidden border-b border-gray-200 sm:rounded-lg"
        >
          <table class="min-w-full divide-y divide-gray-200">
            <thead class="bg-gray-50">
              <tr>
                <th
                  scope="col"
                  class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  Name
                </th>
                <th
                  scope="col"
                  class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  Title
                </th>
                <th
                  scope="col"
                  class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  Status
                </th>
                <th
                  scope="col"
                  class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  Role
                </th>
                <th scope="col" class="relative px-6 py-3">
                  <span class="sr-only">Edit</span>
                </th>
              </tr>
            </thead>
            <tbody class="bg-white divide-y divide-gray-200">
              <tr v-for="consulta in object.consultas" :key="consulta.id">
                <td class="px-6 py-4 whitespace-nowrap">
                  <div class="flex items-center">
                    <div class="flex-shrink-0 h-10 w-10">
                      <img
                        class="h-10 w-10 rounded-full"
                        src="https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=4&w=256&h=256&q=60"
                        alt=""
                      />
                    </div>
                    <div class="ml-4">
                      <div class="text-sm font-medium text-gray-900">
                        {{ consulta.paciente }}
                      </div>
                      <div class="text-sm text-gray-500">
                        {{ formataData(consulta.dataConsulta) }}
                      </div>
                    </div>
                  </div>
                </td>
                <td class="px-6 py-4 whitespace-nowrap">
                  <div class="text-sm text-gray-900">
                    {{ consulta.profissional }}
                  </div>
                  <div class="text-sm text-gray-500">
                    {{ especialidadeFormatada(consulta.especialidades) }}
                  </div>
                </td>
                <td class="px-6 py-4 whitespace-nowrap">
                  <span
                    class="px-2 inline-flex text-xs leading-5 font-semibold rounded-full"
                    :class="corBackgroundCard(consulta.status)"
                  >
                    {{ consulta.nomeStatus }}
                  </span>
                </td>
                <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                  Admin
                </td>
                <td
                  class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium"
                >
                  <a href="#" class="text-indigo-600 hover:text-indigo-900"
                    >Edit</a
                  >
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, reactive } from "vue";
import api from "../service";
import { dataAtualFormatada } from "../utils/dataFormatada";
export default {
  setup() {
    const object = reactive({
      consultas: []
    });

    onMounted(async () => {
      const { data } = await api.get("Consulta/");
      object.consultas = data;
      console.log(object.consultas);
    });

    function especialidadeFormatada(especialidades) {
      return especialidades.join(", ");
    }

    function formataData(dataConsulta) {
      return dataAtualFormatada(dataConsulta);
    }

    function corBackgroundCard(status) {
      switch (status) {
        case 1:
          return "text-silver-200 bg-yellow-300";
        case 2:
          return "text-green-800 bg-green-100";
        case 3:
          return "text-red-900 bg-red-100";
        default:
          return "text-indigo-400 bg-indigo-100";
      }
    }

    return {
      object,
      especialidadeFormatada,
      dataAtualFormatada,
      formataData,
      corBackgroundCard
    };
  }
};
</script>

<style lang="scss" scoped></style>
