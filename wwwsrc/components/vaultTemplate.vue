<template>
  <div class="vaultTemplate">
    <drop @drop="addToVault" class="col-11 border my-2">
      <p>{{vault.name}}</p>

      <button class="btn btn-outline-danger btn-sm" @click="deleteVault(vault.id)">delete</button>
    </drop>
  </div>
</template>


<script>
  import { Drag, Drop } from 'vue-drag-drop';
  export default {
    name: 'vaultTemplate',
    props: ["vault"],
    data() {
      return {}
    },
    computed: {
    },
    methods: {
      addToVault(keep) {
        let payload = {
          vaultId: this.vault.id,
          userId: this.$store.state.user.id,
          keepId: keep.id
        }
        this.$store.dispatch("addToVault", payload)
      },
      deleteVault(id) {
        this.$store.dispatch("deleteVault", id)
      }
    },
    components: {
      Drag,
      Drop
    }
  }
</script>


<style scoped>

</style>