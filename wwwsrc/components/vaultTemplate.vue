<template>
  <div class="vaultTemplate">
    <drop v-if="this.vault.id % 2 == 0" @drop="handleDrop" class="col-12 bordR bgBlue border-dark rounded my-2">
      <p class="m-1">{{vault.name}}</p>
      <hr class="bg-white m-0">
      <div class="row mt-4 d-flex justify-content-around">
        <img class="rounded mb-2" v-for="keep in keeps" :src="keep.img" id="vaultKeep" />
      </div>
    </drop>
    <drop v-else @drop="handleDrop" class="col-12 bordR bgPurp border-dark rounded my-2">
      <p class="m-1">{{vault.name}}</p>
      <hr class="bg-white m-0">
      <div class="row mt-4 d-flex justify-content-around">
        <img class="rounded mb-2" v-for="keep in keeps" :src="keep.img" id="vaultKeep" />
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
    max-height: 75px;
    width: auto;
  }

  .bgPurp {
    background: #fc0095;
  }

  .bgBlue {
    background-color: #007bff;
  }
</style>