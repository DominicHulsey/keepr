<template>
  <div class="vaultTemplate col-4">
    <drop v-if="this.vault.id % 2 == 0" @drop="handleDrop"
      class="row mx-2 bordR bgBlue justify-content-center border-dark mobile rounded my-2">
      <p class="m1 col-12 mx-2">{{vault.name}}</p>
      <hr class="bg-white m-0 col-10">
      <div class="row justify-content-center">
        <img class="rounded mb-5 px-0 col-2" v-for="keep in keeps" :src="keep.img" id="vaultKeep" />
      </div>
    </drop>
    <drop v-else @drop="handleDrop" class=" bordR bgPurp row mx-2 border-dark justify-content-center rounded my-2">
      <p class="m-1 col-12 mx-2">{{vault.name}}</p>
      <hr class="bg-white m-0 col-10">
      <div class="row justify-content-center">
        <img class="rounded mb-5 px-0 col-2 " v-for="keep in keeps" :src="keep.img" id="vaultKeep" />
      </div>
    </drop>
  </div>
</template>


<script>
  import { Drag, Drop } from 'vue-drag-drop';
  export default {
    name: 'vaultTemplate',
    props: ["vault", "keep"],
    mounted() {
      this.$store.dispatch("getVaultKeeps", this.vault.id)
    },
    data() {
      return {
      }
    },
    computed: {
      keeps() {
        return this.$store.state.vaultkeeps[this.vault.id]
      },
      loggedIn() {
        return this.$store.state.user.id
      }
    },
    methods: {
      handleDrop(keep) {
        let payload = {
          vaultId: this.vault.id,
          userId: this.$store.state.user.id,
          keepId: keep.id
        }
        this.$store.dispatch("addToVault", payload)
      },
      deleteVault(id) {
        this.$store.dispatch("deleteVault", id)
      },
    },
    components: {
      Drag,
      Drop,
    }
  }
</script>


<style scoped>
  #vaultKeep {
    max-height: 40px;
    width: auto;
  }

  .mobile {
    min-height: 20vh !important;
  }

  .bgPurp {
    background: #fc0095;
  }

  .bgBlue {
    background-color: #007bff;
  }
</style>